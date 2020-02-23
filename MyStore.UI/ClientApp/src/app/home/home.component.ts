import { Component } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  private size = 10;
  public page = 1;
  public total = 0;

  public data: any;
  public categories: any;

  public name: string;
  public category: number;

  constructor (private http: HttpClient){};
   ngOnInit(){
     this.loadData();
     this.loadCategories();
   }

   public loadCategories(){
    this.http.get<any>("https://localhost:44316/Home/GetCategories").subscribe(
      x => {
        this.categories = x;
      }
    );
   }

   public create(){
    if(!this.category && !this.name){
      return;
    }
    const body = {ProductName: this.name, CategoryID: +this.category};
    this.http.post('https://localhost:44316/Home/Create', body).subscribe(x => {
      this.loadData();
    }); 
   }

   public previous(){
     if(this.page <= 1){
      return;
     }
     this.page--;
     this.loadData();
   }

   public next(){
     debugger;
     let isItems = (this.page * this.size) < this.total;
     if(!isItems){
      return;
     }
     this.page++;
     this.loadData();
   }
  public loadData(){
    this.http.get<any>("https://localhost:44316/Home/GetAll?pageNumber=" + this.page + "&pageSize=" + this.size).subscribe(
      x => {
        this.data = x;
        this.total = x.totalItemsCount
      }
    );
  }
}
