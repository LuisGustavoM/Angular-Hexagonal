import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { EnvService } from './core/services/env.service';
import { FontAwesomeLibraryConfig } from './core/font-awesome-library';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
    CommonModule,
    NavbarComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'] 
})
export class AppComponent {
   
  routerService: Router = inject(Router);
  envService = inject(EnvService);
  fontAwesomeLibraryConfig = inject(FontAwesomeLibraryConfig);

  ngOnInit() {
    this.envService.setUrlApi();
  }

  public isHomePage(): boolean {
    return window.location.pathname === '/';
  }

  public navigateToHome(): void {
    this.routerService.navigate(['']);
  }
}