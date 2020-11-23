import { Component, OnInit } from '@angular/core';
import { WidgetBaseComponent } from '../widget-base/widget-base.component';

@Component({
  selector: 'app-widgetcount',
  templateUrl: './widget-count.component.html',

})
export class WidgetCountComponent extends WidgetBaseComponent implements OnInit {

  constructor() {
    super();
  }

  ngOnInit() {
  }

}
