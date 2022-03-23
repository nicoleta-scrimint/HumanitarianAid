import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';

import { HeaderComponent } from './header/header.component';
import { BreadcrumbsComponent } from './breadcrumbs/breadcrumbs.component';
import { SidemenuComponent } from './sidemenu/sidemenu.component';
import { RouterModule } from '@angular/router';



const materialImports = [
  MatToolbarModule,
  MatIconModule,
  MatButtonModule,
  MatSidenavModule,
  MatListModule
]

@NgModule({
  declarations: [
    HeaderComponent,
    BreadcrumbsComponent,
    SidemenuComponent
  ],
  imports: [
    CommonModule,
    materialImports,
    RouterModule
  ],
  exports: [
    HeaderComponent,
    SidemenuComponent
  ]
})
export class LayoutModule { }
