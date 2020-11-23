import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { UtilityService } from 'app/core/services/utility.service';

@Component({
  selector: 'app-attachement',
  templateUrl: './attachement.component.html',
  styleUrls: ['./attachement.component.scss']
})
export class AttachementComponent implements OnInit {
 
  private _viewModel: any;

  @Input() set viewModel(value: any) {
    this._viewModel = value;
  }

  get viewModel(): any {
    return this._viewModel;
  }

  constructor(public utilityService: UtilityService,) { }

  ngOnInit() {
  }


  deleteAttachement(i, name) {
    this.viewModel[name] = [];
    this.viewModel[name].displayName = "";
  }

  onBasicUpload(event, i, name): void {
    var count = 0;
    var displayName="";
    this.viewModel[name] = Array.from(event.files);

    for (const file of event.files) {
      displayName = count < event.files.length - 1  ? displayName + file.name + " , <br/>" : displayName + file.name
      count++;
    }
    
    this.viewModel[name].displayName = displayName;
  }

 
}
