/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        transpiler: 'ts',
        typescriptOptions: {
            tsconfig: true
        },
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            app: 'app',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            '@ng-bootstrap/ng-bootstrap': 'npm:@ng-bootstrap/ng-bootstrap/bundles/ng-bootstrap.js',
            // other libraries
            'rxjs': 'npm:rxjs',
            'moment': 'npm:moment',
            'ng2-bootstrap-modal': 'npm:ng2-bootstrap-modal',
            'bootstrap': 'npm:bootstrap/dist/js/bootstrap.min.js',
            'jquery': 'npm:jquery/dist/jquery.min.js',
            'prodesp-core': 'npm:prodesp-core/bundles/prodesp-core.umd.js',
            'prodesp-ui': 'npm:prodesp-ui/bundles/prodesp-ui.umd.js',
            'prodesp-gsnet-monitor': 'npm:prodesp-gsnet-monitor/bundles/prodesp-gsnet-monitor.umd.js'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                main: 'main.js', defaultExtension: 'js'
            },
            'moment': {
                main: 'moment.js',
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: 'systemjs-angular-loader.js'
                    }
                }
            },
            rxjs: {
                main: 'Rx.js',
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: 'systemjs-angular-loader.js'
                    }
                }
            },
            'ng2-bootstrap-modal': {
                main: 'index.js',
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: 'systemjs-angular-loader.js'
                    }
                }
            }
        }
    });
})(this);
