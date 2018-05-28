import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AuthHttp } from 'angular2-jwt/angular2-jwt';
import 'rxjs/add/operator/map';
import { SaveQuestion } from '../models/question.models';

@Injectable()
export class QuestionService {
  originUrl:string;
  constructor(private http: Http, 
    private authHttp: AuthHttp,
    @Inject('ORIGIN_URL')originUrl: string) { 
      this.originUrl=originUrl;
    }

  getQuestions(filter){
    return this.http.get(this.originUrl+'/api/questions?'+this.toQueryString(filter))
      .map(res => res.json());
  }

  toQueryString(obj){
    var parts = [];
    console.log('toQueryString');
    for (var prop in obj){
      var value = obj[prop];
      // console.log(prop);
      // console.log(value);
      if(value != null && value != undefined){
        parts.push(encodeURIComponent(prop) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }

  getQuestion(questionid){
    return this.http.get(this.originUrl+'/api/questions/'+questionid)
      .map(res => res.json());
  }

  deleteQuestion(questionid){
    return this.authHttp.delete(this.originUrl+'/api/questions/'+questionid)
      .map(res => res.json());
  }
  
  createQuestion(question){
    return this.authHttp.post(this.originUrl+'/api/questions/new', question)
      .map(res => res.json());
  }

  updateQuestion(question){
    return this.authHttp.put(this.originUrl+'/api/questions/'+question.id, question )
      .map(res => res.json());
  }

  addAnswer(questionid, answer){
    return this.authHttp.post(this.originUrl+'/api/questions/'+questionid, { id: 0, details: answer })
      .map(res => res.json());
  }

  addReply(questionid, answerid, reply){
    return this.authHttp.post(this.originUrl+'/api/questions/'+questionid+'/'+answerid, { details: reply })
      .map(res => res.json());
  }
}
