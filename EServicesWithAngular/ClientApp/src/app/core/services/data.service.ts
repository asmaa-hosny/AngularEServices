import { Injectable, EventEmitter, Output } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { EventType } from 'app/shared/helpers/enum';
import { EventData } from 'app/model/emitEvent';
import { filter, map } from 'rxjs/operators';
import { ReturnStatement } from '@angular/compiler';

@Injectable()
export class DataService {
    item: any = {};
    private subject = new Subject<any>();
    @Output() submitAction: EventEmitter<boolean> = new EventEmitter();


    constructor() { }

    sendMessage(EventData) {
        this.subject.next(EventData);
    }

    clearMessage(EventData) {
        this.subject.next();
    }

    getMessage(event: EventType, jobId = undefined, nodeId = undefined): Observable<any> {
        return this.subject.asObservable().pipe(
            filter((e: EventData) => {
                if (jobId && nodeId)
                    return e.eventName === event && e.eventValue.jobId && e.eventValue.jobId === jobId && e.eventValue.nodeId === nodeId;
                else
                    return e.eventName === event;
            }),
            map((e: EventData) => {
                return e.eventValue;
            }));
    }

    submitChangeAction(item) {
        this.item.jobId = item.jobId;
        this.item.comment = item.comment;
        this.item.id = item.id;
        this.item.status = item.status;
        this.item.error = item.error;
        this.submitAction.emit(this.item);
    }
}