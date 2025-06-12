const path = require('path');
const {workspaces, schema} = require('@angular-devkit/core/index');
const {NodeJsSyncHost} = require('@angular-devkit/core/node/index');
const {Architect} = require('@angular-devkit/architect/index');
const {WorkspaceNodeModulesArchitectHost} = require('@angular-devkit/architect/node/index');

module.exports = async (targetSpec, options) => {
    console.debug('targetSpec', targetSpec);
    console.debug('targetOptions', options);

    const executionFolderPath = process.cwd();
    const workspacePath = path.join(executionFolderPath, 'angular.json');
    console.debug('Workspace path:', workspacePath);
    const nodeJsSyncHost = new NodeJsSyncHost();
    const host = workspaces.createWorkspaceHost(nodeJsSyncHost);
    const {workspace} = await workspaces.readWorkspace(workspacePath, host);
    const architectHost = new WorkspaceNodeModulesArchitectHost(workspace, executionFolderPath);
    const registry = new schema.CoreSchemaRegistry();
    registry.addPostTransform(schema.transforms.addUndefinedDefaults);
    const architect = new Architect(architectHost, registry);

    let run;
    try {
        console.debug('Scheduling target:', targetSpec.target);
        run = await architect.scheduleTarget(targetSpec, options);

        await new Promise((resolve, reject) => {
            const progressSubscription = run.progress.subscribe({
                next: event => {
                    switch (event.state) {
                        case 'running':
                            console.info('Building...');
                            break;
                        case 'stopped':
                            console.info('Build completed');
                            break;
                    }
                },
                error: err => {
                    console.error('Progress Error:', err);
                    progressSubscription.unsubscribe();
                    subscription?.unsubscribe();
                    run.stop();
                    reject(err);
                },
            });

            const subscription = run.output.subscribe({
                error: err => {
                    console.error('Error:', err);
                    subscription.unsubscribe();
                    progressSubscription.unsubscribe();
                    run.stop();
                    reject(err);
                },
                complete: () => {
                    subscription.unsubscribe();
                    progressSubscription.unsubscribe();
                    run.stop();
                    resolve();
                },
            });
        });

        console.debug('Target scheduled successfully:', targetSpec.target);

        return await run.result;
    } catch (error) {
        console.error('Error scheduling target:', error);
        if (run) {
            try {
                run.stop();
            } catch (stopError) {
                console.error('Error stopping run:', stopError);
            }
        }
        return error;
    }
}
