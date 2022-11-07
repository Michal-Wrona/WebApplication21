import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = 'https://localhost:7200/api/'


  constructor(private http: HttpClient) { }


  getBooks() {
    return this.http.get<Book[]>(this.baseUrl + 'book')
  }
}
