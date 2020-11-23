import { Component, OnInit, Input,ChangeDetectionStrategy, SimpleChanges, SimpleChange } from '@angular/core';

@Component({
  selector: 'widget-base-component',
  template: '',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WidgetBaseComponent implements OnInit {
  @Input() typeCount: number;
  @Input() title: string;

  private _desc; // private property _item

  // use getter setter to define the property
  get describtion(): any { 
    return this._desc;
  }
  
  @Input()
  set describtion(val: any) {
    this._desc = val;
  }

 
  @Input() iconName: string;
  @Input() smallIconName: string;
  @Input() classvar: string;
  @Input() colList: [];
  @Input() list: any[];
  @Input() displayAction: boolean;
  constructor() { }

  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
   
   
  }

}
