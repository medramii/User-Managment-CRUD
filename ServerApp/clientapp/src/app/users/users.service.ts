import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Users } from './users';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  constructor(private http: HttpClient) {

  }
  get() {
    return this.http.get<Users[]>('https://localhost:44317/api/users/getusers');
  }

  getById(id: number) {
    return this.http.get<Users>(`https://localhost:44317/api/users/getuser/${id}`);
  }

  create(payload: Users) {
    return this.http.post<Users>('https://localhost:44317/api/users', payload);
  }

  update(payload: Users) {
    return this.http.put(`https://localhost:44317/api/users/${payload.idUser}`, payload);
  }
  delete(id: number) {
    return this.http.delete<Users>(`https://localhost:44317/api/users/${id}`);
  }
}

