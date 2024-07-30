import { Component, inject, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { Movie } from '../../models/movie';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { CalendarModule } from 'primeng/calendar';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-movie-maintenance',
  templateUrl: './movie-maintenance.component.html',
  styleUrls: ['./movie-maintenance.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    DialogModule,
    CalendarModule,
    ReactiveFormsModule
  ],
  providers: [MovieService]
})

export class MovieMaintenanceComponent implements OnInit {
  private dialogDataService = inject(DynamicDialogConfig);
  private fb = inject(FormBuilder)


  formGroup: FormGroup;
  movie: Movie;
  
  constructor() { }


  ngOnInit() {
    this.createFormGroup()
  }

  private createFormGroup(){
    this.formGroup = this.fb.group({
      datePublication: ['', Validators.required, Validators.nullValidator],
      name: ['', Validators.required, Validators.nullValidator]
    });

    this.getMovie();
  }

  private getMovie(){
    this.movie = this.dialogDataService.data.movie;
    if(this.movie != null) this.setDataForm();
  }

  private setDataForm(){
    this.formGroup.setValue({
      dataPublication: this.movie.DatePublication,
      name: this.movie.name
    });
  }

  closeModal(){

  }
}
