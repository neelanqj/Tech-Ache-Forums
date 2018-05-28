import { QuestionService } from '../../services/question.service';
import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-view-question',
  templateUrl: './view-question.component.html',
  styleUrls: ['./view-question.component.css','../app/app.component.css'],
  providers: [ QuestionService ]
})
export class ViewQuestionComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef;
  buttonsVisible = true;
  question: any  = {
    id: 0,
    title: '',
    details: '',
    user: {
      firstName: '',
      lastName: ''
    },
    upvotes: 0,
    views: 0,
    tags: [{id: 0, name: ''}],
    questionExtensions: [{
      id:0,
      details:''
    }],
    answers: [
      {
        upvotes: 0,
        details: '',
        createdate: '',
        user: {
          firstName:'',
          lastName:''
        },
        replies: []
      }
    ]
  };
  questionId: number; 
  questionCreator: boolean;
  questionExtension: string;
  questionAnswer: string;
  busy: Subscription;

  constructor(
    private zone: NgZone,
    private route: ActivatedRoute, 
    private router: Router,
    private questionService: QuestionService) { 

    route.params.subscribe(p => {
      this.questionId = +p['id'];
      console.log(this.questionId);
    });
  }

  ngOnInit() { 
    this.busy = this.questionService.getQuestion(this.questionId)
      .subscribe(
        q => {
          this.question = q;
        });
      this.questionCreator = false;
  }

  toggleButtonVisibility(){
    this.buttonsVisible = !this.buttonsVisible;
  }

  updateQuestion(){
    this.question.questionExtensions.push({
      id: '0',
      details: this.questionExtension
    });

    this.questionService.updateQuestion(this.question)
    .subscribe(q => {
          console.log("redirecting");
          this.router.navigate(['/questions/'+q.id]);
        });
  }

  addAnswer(){
    this.question.answers.push({
      id: '0',
      details: this.questionAnswer
    });

  this.questionService.addAnswer(this.question.id, this.questionAnswer)
  .subscribe(q => {
        location.reload();
      });
  }

  addReply(answerid, reply){
    this.questionService.addReply(this.question.id, answerid, reply)
    .subscribe(r=> {
      location.reload();
    });
  }
  
}