import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BtnComponent } from '../../../../shared/btn/btn.component';
import { FormsModule } from '@angular/forms';
import { Movie } from '../../models/movie';
import { FormatDateService } from '../../../../shared/services/format-date.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    DialogModule,
    BtnComponent,
    FormsModule
],
})

export class MovieDetailComponent implements OnInit {
  private dialogRefService = inject(DynamicDialogRef);
  private dialogDataService = inject(DynamicDialogConfig);
  public movie: Movie;

  ngOnInit() {
    this.getMovie();
  }

  private getMovie(){
    this.movie = this.dialogDataService.data.movie;
  }

  closeModal() {
    this.dialogRefService.close();
  }
}
