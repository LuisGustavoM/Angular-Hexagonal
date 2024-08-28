import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'btn-icon',
  templateUrl: './btn-icon.component.html',
  styleUrls: ['./btn-icon.component.css'],
  standalone: true,
  inputs: ['title', 'icon'],
  outputs: ['click'],
  imports: [
    CommonModule,
    FontAwesomeModule
  ]
})

export class BtnIconComponent {
  @Input() icon: string;
  @Input() title: string;
  @Output() click: EventEmitter<any> = new EventEmitter();

  btnClick(){
    this.click.emit();
  }
}
