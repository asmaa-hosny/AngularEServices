import { Injectable } from '@angular/core';
import * as clone from 'clone'
@Injectable()
export class CloneService {
    
    deepClone<T>(value): T {
        return clone<T>(value);
    }
}
