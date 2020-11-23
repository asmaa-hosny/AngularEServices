import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[read-only]'
})
export class ReadOnlyDirective {
  inputElement: HTMLElement;
 
  constructor(public el: ElementRef) {
    this.inputElement = el.nativeElement;
  }

  @HostListener('keydown', ['$event'])
  onKeyDown(e: KeyboardEvent) {
   
      e.preventDefault();
    
  }


}
