import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterText'
})
export class FilterTextPipe implements PipeTransform {

  transform(items: any[], searchText: string, specificField?: string): any[] {
    if (!items)
        return [];

    if (!searchText)
        return items;

    const lowerSearchText = searchText.toLocaleLowerCase();

    if (specificField) {
        return items.filter(item => item.hasOwnProperty(specificField) && (item[specificField].toString() as string).toLocaleLowerCase().includes(lowerSearchText));
    } else {
        return items.filter(item => {
            if (!item) {
                return false;
            } else if (typeof (item) === 'string') {
                return item.toLocaleLowerCase().includes(lowerSearchText);
            } else {
                for (const field of Object.keys(item)) {
                    if ((item[field].toString() as string).toLocaleLowerCase().includes(lowerSearchText))
                        return true;
                }
            }

            return false;
        });
    }
}

}
