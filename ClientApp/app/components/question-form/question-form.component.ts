import * as _ from 'underscore';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { SaveQuestion, Question } from '../../models/question.models';
import { QuestionService } from './../../services/question.service';
import { ToastyService } from 'ng2-toasty';
import 'rxjs/add/Observable/forkJoin';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.css','../app/app.component.css'],
  providers:[
    QuestionService
  ]
})
export class QuestionFormComponent implements OnInit {
  question: SaveQuestion = {
    id: null,
    title: '',
    details:'',
    userid: 1,
    questionExtensions:[]
  };
  showModal = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private QuestionService: QuestionService, 
    private toastyService: ToastyService) { 
      route.params.subscribe(p => {
        this.question.id = +p['id'] || 0;
      });
    }

  ngOnInit() {
    var sources = [];

    if (this.question.id){
      sources.push(this.QuestionService.getQuestion(this.question.id));
    }
  }

  private setQuestion(q: Question){
    this.question.id = q.id;
  }

  submit(){
    if(this.question.id){
      this.QuestionService.updateQuestion(this.question)
        .subscribe(v => {
          this.toastyService.success({
            title: 'success',
            msg:'The question was successfully updated.',
            theme:'bootstrap',
            showClose:true,
            timeout: 5000
          });
        });
    } else {
      this.QuestionService.createQuestion(this.question)
        .subscribe(x=>{
          this.router.navigate(['/questions/'+x.id]);
        });
    }
  }

  delete(){
    if(confirm("Are you sure?")){
      this.QuestionService.deleteQuestion(this.question.id)
        .subscribe(x=>{
          this.router.navigate(['/home']);
        });
    }
  }

  toggleModal(){
    if(this.question.title.length > 20)
      this.showModal = !this.showModal;
  }
}
