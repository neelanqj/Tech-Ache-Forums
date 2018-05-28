
import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import { QuestionService } from '../../services/question.service';
import { Subscription } from "rxjs/Subscription";

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css','../app/app.component.css'],
  providers: [
    QuestionService
  ]
})
export class QuestionListComponent implements OnInit {
  private readonly PAGE_SIZE = 3; 
  allQuestions: any[];
  queryResult: any = {};
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Id' },
    { title: 'Title', key: 'title', isSortable: true },
    { title: 'Description', key: 'description', isSortable: true },
    { title: 'CreateDate', key: 'createdate', isSortable: true }
  ];
  busy: Subscription;

  constructor(
    private QuestionService: QuestionService
  ) { }

  ngOnInit() {
    this.QuestionService.getQuestions(this.query).subscribe(
     Questions => this.queryResult = Questions
    );

    this.populateQuestions();
  }

  private populateQuestions(){
    this.busy = this.QuestionService.getQuestions(this.query).subscribe(
     result => this.queryResult = result
    )
  }

  sortBy(colName) {
    if(this.query.sortBy === colName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = colName;
      this.query.isSortAscending = true;
    }
    this.populateQuestions();
  }

  onFilterChange(){
    this.query.page = 1;
    this.query.pageSize = this.PAGE_SIZE;
    this.populateQuestions();
  }

  resetFilter(){
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateQuestions();
  }

  onPageChange(page){
    this.query.page = page;
    this.populateQuestions();
  }
}
