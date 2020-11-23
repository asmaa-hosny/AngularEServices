import { Component, OnInit, Input } from '@angular/core';
import { LocalizationService } from 'app/core/services/localization.service';

@Component({
  selector: 'profile-data',
  templateUrl: './requester-data.component.html',
  styleUrls: ['./requester-data.component.scss']
})
export class RequesterDataComponent implements OnInit {
  @Input() employee: any
  isEnglish
  constructor(public localizationservice: LocalizationService) { }

  ngOnInit() {
    this.isEnglish = this.localizationservice.isEnglish;
  }

}
