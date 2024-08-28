import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { RatingModule } from 'primeng/rating';
import { TagModule } from 'primeng/tag';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../models/movie';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';
import { MovieMaintenanceComponent } from '../movie-maintenance/movie-maintenance.component';
import { BtnComponent } from '../../../../shared/btn/btn.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BtnIconComponent } from '../../../../shared/btn-icon/btn-icon.component';
import { MovieDetailComponent } from '../movie-detail/movie-detail.component';

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
    FontAwesomeModule,
    BtnIconComponent,
  ],
  providers: [
    MovieService,
    DialogService
  ]
})
export class MovieListComponent implements OnInit {
  
  private dialogService = inject(DialogService);
  private movieService = inject(MovieService);

  movieList: Movie[]= [];
  constructor() { }

  ngOnInit() {
    this.getMoviesList();
  }
  
  public getMoviesList(){
    this.movieService.getMovieList().subscribe(movieList => {
      this.movieList = movieList;
    });
  }

  public goMaintenance(movie: Movie | null, edit = false){
    const title = movie == null ? 'Add new item' : 'Edit item';
    this.dialogService.open(MovieMaintenanceComponent, 
      { 
        header: title, 
        data: this.defineDataDialog(movie, edit),
        width: '40%',
        height: 'auto',
        closable: false
      });
  }

  public goDetail(movie: Movie){
    this.dialogService.open(MovieDetailComponent,
      { 
        header: 'Detail movie', 
        data: this.defineDataDialog(movie),
        width: '40%',
        height: 'auto',
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
