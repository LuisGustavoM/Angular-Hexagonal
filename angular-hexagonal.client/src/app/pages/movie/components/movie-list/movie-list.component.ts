import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { RatingModule } from 'primeng/rating';
import { TagModule } from 'primeng/tag';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../models/movie';
import { DialogService, DynamicDialogModule, DynamicDialogRef } from 'primeng/dynamicdialog';
import { MovieMaintenanceComponent } from '../movie-maintenance/movie-maintenance.component';
import { BtnComponent } from '../../../../shared/btn/btn.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    RatingModule,
    TagModule,
    DynamicDialogModule,
    BtnComponent,
    FontAwesomeModule 
  ],
  providers: [
    MovieService,
    DialogService
  ]
})
export class MovieListComponent implements OnInit {
  
  private dialogService = inject(DialogService);
  private movieService = inject(MovieService);
  private ref: DynamicDialogRef | undefined;

  movieList: Movie[]= [];
  constructor() { }

  ngOnInit() {
    this.getMoviesList();
  }
  
  private getMoviesList(){
    this.movieService.getMovieList().subscribe(movieList => {
      this.movieList = movieList;
    });
  }

  public goMaintenance(movie: Movie | null, edit = false){
    const title = movie == null ? 'Add new item' : 'Edit item';
    this.ref = this.dialogService.open(MovieMaintenanceComponent, 
      { 
        header: title, 
        data: this.defineDataDialog(movie, edit),
        width: '40%',
        height: '60%',
        closable: false
      });
  }

  private defineDataDialog(movie: Movie | null, edit = false){
    return  {
      movie: movie, 
      edit: edit
    } 
  }

}
