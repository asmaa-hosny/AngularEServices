import { TranslateService } from "@ngx-translate/core";
import { Injectable } from "@angular/core";
import * as moment from 'moment';
import { environment } from "environments/environment";

@Injectable()
export class UtilityService {

  constructor(public translate: TranslateService) {
  }

  public isEditableField(fields: any[], fieldName) {
    if (fields) {
      var result = fields.filter(item => item.fieldName == fieldName);
      if (!result || !result[0]) return true;
      else if (result[0] && result[0].editable) return true;
      else
        return false;
    }
    return true;

  }

  public isVisibleField(fields: any[], fieldName) {
    if (fields) {
      var result = fields.filter(item => item.fieldName == fieldName);
      if (!result || !result[0]) return true;
      else if (result[0] && result[0].visible) return true;
      else
        return false;
    }
    return true

  }

  public getPattern(fields: any[], fieldName) {
    if (fields) {
      var result = fields.filter(item => item.fieldName == fieldName);
      if (result[0] && result[0].pattern) return result[0].pattern;
      else
        return "";
    }
    return ""

  }


  public isRequiredField(fields: any[], fieldName) {
    if (fields) {
      var result = fields.filter(item => item.fieldName == fieldName);
      if (result[0] && result[0].required) return true;
      else
        return false;
    }
    return false

  }



  public getEnumOptions(enumObj) {
    var Options = Object.keys(enumObj);
    Options = Options.slice(Options.length / 2);
    console.log(Options);
    return Options
  }

  getEnumList(enumType, enumValueMax: number = 1000000 ,enumValueMin: number = 0) {

    let items: any[] = [];

    for (let key in enumType) {
      var isValueProperty = parseInt(key, 10) >= enumValueMin && parseInt(key, 10) <= enumValueMax;

      if (!isValueProperty)
        continue;

      this.translate.get('Text.' + enumType[key]).subscribe((res: string) => {
        items.push({ value: key, text: res });
      });

    }
    return items;
  }


  public calendarArabicLocale: any = {
    firstDayOfWeek: 1,
    dayNames: ["الاحد", "الأثنين", "الثلاثاء", "الاربعاء", "الخميس", "الجمعة", "السبت"],
    dayNamesShort: ["الاحد", "الأثنين", "الثلاثاء", "الاربعاء", "الخميس", "الجمعة", "السبت"],
    dayNamesMin: ["الاحد", "الأثنين", "الثلاثاء", "الاربعاء", "الخميس", "الجمعة", "السبت"],
    monthNames: ["يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو", "يوليو", "اغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
    monthNamesShort: ["يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو", "يوليو", "اغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
    clear: 'مسح'
  };

  public calendarEnglishLocale: any = {
    firstDayOfWeek: 1,
    dayNames: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
    dayNamesShort: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
    dayNamesMin: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"],
    monthNames: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
    monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
    clear: 'Clear'
  }



  convertToApiDate(value: Date, isDateTime: boolean = true, isUtc: boolean = true) {

    if (!value)
      return value;

    var valDate = moment(value, environment.dateFormat.dateWithTime)

    if (isDateTime) {

      if (isUtc === true) {
        var valDate = moment.utc(value, environment.dateFormat.dateWithTime);
        return valDate.format(environment.dateFormat.apiDateWithTime);
      }

      else {
        return valDate.format(environment.dateFormat.apiDate);
      }

    }
    var result = valDate.format(environment.dateFormat.apiDate)
    return result;
  }

  convertToLocalDate(value, isDateTime: boolean = true , isParameter : boolean = false) {

    if (!value)
      return value;

    var gmtDateTime = moment.utc(moment(value).format("YYYY-MM-DD HH:mm:ss"), "YYYY-MM-DD HH:mm:ss");

    if (isDateTime === true)
      return gmtDateTime.local().format(environment.dateFormat.dateWithTime);
    
      if(isParameter == true)
      return gmtDateTime.local().format((environment.dateFormat.apiDateparm));

    return gmtDateTime.local().format(environment.dateFormat.date);
   
  }

  getDateDiffrenceDays(startDate, endDate) {

    var startDateValue = moment(startDate, environment.dateFormat.date)
    var endDateValue = moment(endDate, environment.dateFormat.date)
    var diff = startDateValue.diff(endDateValue, 'days')
    // console.log('Difference is ', startDateValue.diff(endDateValue), 'milliseconds');
    // console.log('Difference is ', startDateValue.diff(endDateValue, 'days'), 'days');
    // console.log('Difference is ', startDateValue.diff(endDateValue, 'months'), 'months');

    console.log(diff);
    return diff;


  }

  getItemByIndex(index, list: any[], columnName="id") {
    
    var item = null
    if (index != null)
      if (list && list.length > 0) {

        var item = list.find(function (element) {
          return element && element[columnName] ? element[columnName].toString() === index.toString() : element.value ? element.value.toString() === index.toString() :  null;
        });
      }

    return item;

  }

  

  getPatchArray(model) {
    let patcharray = []
    let index = 0;
    Object.keys(model).forEach(innerkey => {
      patcharray[index] = {};
      patcharray[index]["op"] = "replace";
      patcharray[index]["path"] = innerkey;
      patcharray[index]["value"] = model[innerkey];
      index++;
    });
    return patcharray;
  }

}

