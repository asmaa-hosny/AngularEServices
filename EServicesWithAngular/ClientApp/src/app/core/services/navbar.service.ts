import { Injectable, EventEmitter, Output } from '@angular/core';

@Injectable()
export class NavbarService {
    showEmployees: boolean=false;
    @Output() change: EventEmitter<boolean> = new EventEmitter();
    empId = 0;

    constructor() { }

    hide() { this.showEmployees = false; }

    show() { this.showEmployees = true; }

    toggle() { this.showEmployees = !this.showEmployees; }

    ChangeEmployee(empId) {
        this.empId = empId;
        this.change.emit(empId);
    }
}