import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'movies',
        loadComponent: () => import('./pages/movie/components/movie-list/movie-list.component').then(c => c.MovieListComponent),
        data: {breadcrump: 'movies'}
    },
];
