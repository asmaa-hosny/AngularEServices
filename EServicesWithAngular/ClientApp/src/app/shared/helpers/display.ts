import { DecoratorService } from "app/core/services/decorator.service";

export function Display(Key: string) {

    return function (target: any, propertyName: string) {
        const translateService = DecoratorService.getService();
        
        Object.defineProperty(target, propertyName+"Title", {
            configurable: false,
            get: () =>
            {
                return translateService.instant(Key);
            }


        });
    }
}

