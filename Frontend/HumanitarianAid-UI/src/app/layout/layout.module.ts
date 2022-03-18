import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { BreadcrumbsComponent } from './breadcrumbs/breadcrumbs.component';
import { SidemenuComponent } from './sidemenu/sidemenu.component';



@NgModule({
  declarations: [
    HeaderComponent,
    BreadcrumbsComponent,
    SidemenuComponent
  ],
  imports: [
    CommonModule
  ]
})
export class LayoutModule { }
