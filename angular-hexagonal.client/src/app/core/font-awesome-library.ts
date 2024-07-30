// font-awesome-library.config.ts
import { Injectable } from "@angular/core";
import { FaIconLibrary } from "@fortawesome/angular-fontawesome";
import { faSquare, faCheckSquare, faRemove } from "@fortawesome/free-solid-svg-icons";
// import { faSquare as farSquare, faCheckSquare as farCheckSquare } from "@fortawesome/free-regular-svg-icons";
// import { faStackOverflow, faGithub, faMedium } from "@fortawesome/free-brands-svg-icons";

@Injectable({
  providedIn: 'root'
})
export class FontAwesomeLibraryConfig {
  constructor(private library: FaIconLibrary) {
    this.addIcons();
  }

  addIcons() {
    this.library.addIcons(
      faSquare,
      faCheckSquare,
      faRemove,
    //   farSquare,
    //   farCheckSquare,
    //   faStackOverflow,
    //   faGithub,
    //   faMedium
    );
  }
}
