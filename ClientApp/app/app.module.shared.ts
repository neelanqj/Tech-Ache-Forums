import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { QuestionListComponent } from './components/question-list/question-list.component';
import { ViewQuestionComponent } from './components/view-question/view-question.component';
import { QuestionFormComponent } from './components/question-form/question-form.component';
import { ToastyModule } from "ng2-toasty";
import { FormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { AuthGuardService } from './services/auth-guard.service';
import { AUTH_PROVIDERS } from "angular2-jwt/angular2-jwt";
import { AppErrorHandler } from './app.error-handler';
import { QuestionService } from './services/question.service';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BusyModule } from 'angular2-busy';
import { PaginationComponent } from './components/shared/pagination.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        QuestionFormComponent,
        QuestionListComponent,
        ViewQuestionComponent,
        HomeComponent,
        PaginationComponent
    ],
    imports: [
        FormsModule,
        BrowserAnimationsModule,
        BusyModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'questions', component: QuestionListComponent, canActivate: [ AuthGuardService ]  },
            { path: 'questions/new', component: QuestionFormComponent, canActivate: [ AuthGuardService ] },
            { path: 'questions/:id', component: ViewQuestionComponent, canActivate: [ AuthGuardService ] },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[
        { provide: ErrorHandler, useClass: AppErrorHandler },
        AuthService,
        AuthGuardService,
        AUTH_PROVIDERS,
        QuestionService
    ]
};
