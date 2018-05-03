import { Directive, OnInit, Input, ElementRef, Renderer } from '@angular/core';


@Directive({
  selector: '[status]'
})
export class ProdespStatusDirective implements OnInit {

  @Input()status: boolean;
  constructor(public el: ElementRef, public renderer: Renderer) {}
  ngOnInit(): void {
    const cssClass: string = this.status ? 'green' : 'red';
    this.renderer.setElementClass(this.el.nativeElement, cssClass, true);
  }
}
