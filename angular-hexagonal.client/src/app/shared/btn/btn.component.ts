import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-btn',
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
  @Output() click: EventEmitter<any> = new EventEmitter();

  constructor() { }

  btnClick(){
    this.click.emit();
  }
}
