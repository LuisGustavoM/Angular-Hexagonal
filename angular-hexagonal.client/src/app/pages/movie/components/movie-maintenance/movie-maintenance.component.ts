import { Component, inject, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { Movie } from '../../models/movie';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BtnComponent } from "../../../../shared/btn/btn.component";
import { FormatDateService } from '../../../../shared/services/format-date.service';

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
    ReactiveFormsModule,
    BtnComponent
],
  providers: [MovieService, FormatDateService]
})

export class MovieMaintenanceComponent implements OnInit {
  private dialogDataService = inject(DynamicDialogConfig);
  private dialogRefService = inject(DynamicDialogRef);
  private formatDateService = inject(FormatDateService);
  private movieService = inject(MovieService);

  private fb = inject(FormBuilder)
  private movie: Movie;

  public form: FormGroup;

  ngOnInit() {
    this.createFormGroup()
  }

  private createFormGroup(){
    this.form = this.fb.group({
      datePublication: [null, Validators.required],
      name: ['', [Validators.required, Validators.maxLength(150)]], 
    });

    this.getMovie();
  }

  private getMovie(){
    this.movie = this.dialogDataService.data.movie;
    this.setDataForm();
  }

  private setDataForm(){
    this.form.patchValue({
      datePublication: this.movie ? this.formatDateService.formatDate(this.movie.datePublication) : null,
      name: this.movie ? this.movie.name : ''
    });
  }

  public saveMovie(){
    const movie = this.form.value;
    this.movieService.saveMovie(movie).subscribe(response => {
      console.log(response);
    });
  }

  closeModal(){
    this.dialogRefService.close();
  }
}
