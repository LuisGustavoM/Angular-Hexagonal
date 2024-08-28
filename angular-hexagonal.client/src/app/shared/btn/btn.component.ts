import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'btn',
  templateUrl: './btn.component.html',
  styleUrls: ['./btn.component.css'],
  standalone: true,
  inputs: ['label', 'type', 'icon', 'size'],
  outputs: ['click'],
  imports: [
    CommonModule,
    FontAwesomeModule
  ]
})
export class BtnComponent{
  @Input() type: number;
  @Input() label: string;
  @Input() icon: string;
  @Input() size: string;
  @Input() disabled: boolean = false;
  @Output() click: EventEmitter<any> = new EventEmitter();


  btnClick(){
    this.click.emit();
  }
}
