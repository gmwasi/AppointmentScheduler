import { authentication } from '../_services/authentication';

export function authHeader() {
    // return authorization header with jwt token
    const currentUser = authentication.currentUserValue;
    if (currentUser && currentUser.token) {
        return { Authorization: `Bearer ${currentUser.token}` };
    } else {
        return {};
    }
}