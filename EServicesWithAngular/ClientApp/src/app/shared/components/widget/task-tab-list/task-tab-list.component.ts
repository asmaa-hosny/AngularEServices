import { Component, OnInit, Input } from '@angular/core';
import { Constants } from 'app/shared/helpers/constants';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-task-tab-list',
  templateUrl: './task-tab-list.component.html',
  styleUrls: ['./task-tab-list.component.scss']
})
export class TaskTabListComponent implements OnInit {
  @Input() tabListcount: number;
  @Input() tabIconList: [];
  @Input() tabNameList: [];
  @Input() title: string;
  @Input() sizeArray;
  @Input() tabsHeader;
  //@Input() tabSourceList;

  private _tabSourceList: any[] = [];
  @Input() set tabSourceList(value: any[]) {
    this._tabSourceList = value;
  }

  get tabSourceList(): any[] {
    return this._tabSourceList;
  }

  @Input() tab1ColList
  @Input() tab1Source: any[];
  @Input() tab1DisplayAction: boolean = false;

  @Input() tab2ColList: [];
  @Input() tab2Source: any[];
  @Input() tab2DisplayAction: boolean;

  @Input() tab3ColList: [];
  @Input() tab3Source: any[];
  @Input() tab3DisplayAction: boolean;
  tab1ColListx: []



  constructor(public translate: TranslateService) {


  }

  ngOnInit() {

    // console.log("1-tab1ColList"+ this.tab1ColList[0].colList);
    // console.log("1-tab1ColList"+ this.tabIconList);

    console.log("1-tab1ColList" + this.tabSourceList);


  }

}
