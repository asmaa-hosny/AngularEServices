import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filter',
    pure: false
})
export class ArrayFilterPipe implements PipeTransform {
    transform(items: any[], type: any): any {
        if (!items || !type) {
            return items;
        }
       
        return items.filter(
            item => item.type.toLowerCase() == type.toLowerCase());
    }
}