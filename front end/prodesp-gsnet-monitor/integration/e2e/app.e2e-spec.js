"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var protractor_1 = require("protractor");
describe('QuickStart Lib E2E Tests', function () {
    beforeEach(function () { return protractor_1.browser.get(''); });
    afterEach(function () {
        protractor_1.browser.manage().logs().get('browser').then(function (browserLog) {
            expect(browserLog).toEqual([]);
        });
    });
    it('should display lib', function () {
        expect(protractor_1.element(protractor_1.by.css('h2')).getText()).toEqual('Hello Angular Library');
    });
    it('should display meaning', function () {
        expect(protractor_1.element(protractor_1.by.css('h3')).getText()).toEqual('Meaning is: 42');
    });
});
//# sourceMappingURL=app.e2e-spec.js.map