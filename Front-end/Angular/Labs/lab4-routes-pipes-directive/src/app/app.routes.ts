import { Routes } from '@angular/router';
import { Home } from './component/home/home';
import { Users } from './component/users/users';
import { UserDetails } from './component/user-details/user-details';
import { About } from './component/about/about';
import { Error } from './component/error/error';

export const routes: Routes = [
    // {path:'', redirectTo:'users', pathMatch:"full"},
    { path: '', component: Home },
    { path: 'users', component: Users },
    { path: 'users/:id', component: UserDetails },
    { path: 'about', component: About },
    { path: '**', component: Error },
];
