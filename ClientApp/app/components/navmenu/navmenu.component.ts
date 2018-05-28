import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html'
})
export class NavMenuComponent {
    constructor(private auth: AuthService){ }
}
