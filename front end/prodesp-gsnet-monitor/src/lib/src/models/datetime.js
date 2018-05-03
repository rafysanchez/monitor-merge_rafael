"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var moment = require("moment");
var Datetime = (function () {
    function Datetime(day, month, year, hour, minutes, seconds, _moment) {
        if (day === void 0) { day = 1; }
        if (month === void 0) { month = 1; }
        if (year === void 0) { year = 1; }
        if (hour === void 0) { hour = 0; }
        if (minutes === void 0) { minutes = 0; }
        if (seconds === void 0) { seconds = 0; }
        this.day = day;
        this.month = month;
        this.year = year;
        this.hour = hour;
        this.minutes = minutes;
        this.seconds = seconds;
        this._moment = _moment;
    }
    Datetime.momentToDatetime = function (m) {
        return new Datetime(m.day(), m.month(), m.year(), m.hour(), m.minute(), m.seconds(), m);
    };
    Datetime.now = function () {
        var m = moment();
        return Datetime.momentToDatetime(m);
    };
    Datetime.prototype.toDateTime = function (dateString) {
        var m = moment(dateString);
        return Datetime.momentToDatetime(m);
    };
    Datetime.prototype.addDays = function (days) {
        var units = 'day';
        var m = this._moment.add(days, units);
        return Datetime.momentToDatetime(m);
    };
    Datetime.prototype.addMonths = function (months) {
        var units = 'month';
        var m = this._moment.add(months, units);
        return Datetime.momentToDatetime(m);
    };
    Datetime.prototype.addYears = function (years) {
        var units = 'year';
        var m = this._moment.add(years, units);
        return Datetime.momentToDatetime(m);
    };
    Datetime.prototype.isEmpty = function () {
        return this.day === 1 && this.month === 1 && this.year === 1;
    };
    Datetime.prototype.equals = function (dateTime) {
        var dateEquals = this.day === dateTime.day && this.month === dateTime.month && this.year === dateTime.year;
        var timeEquals = this.hour === dateTime.hour && this.minutes === dateTime.minutes && this.seconds === dateTime.seconds;
        return dateEquals && timeEquals;
    };
    Datetime.prototype.toString = function () {
        return this._moment.format('DD/MM/YYYY HH:mm:ss');
    };
    Datetime.prototype.toShortDateString = function () {
        return this._moment.format('DD/MM/YYYY');
    };
    Datetime.prototype.toShortTimeString = function () {
        return this._moment.format('HH:mm:ss');
    };
    return Datetime;
}());
exports.Datetime = Datetime;
//# sourceMappingURL=datetime.js.map