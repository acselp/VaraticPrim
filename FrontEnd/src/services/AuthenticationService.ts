export const AuthenticationService = {
  login(userData: AuthData) {
    const strData = JSON.stringify(userData);
    const base64Data = btoa(strData)

    localStorage.setItem(AuthKey, base64Data);
  },

  logout() {
    localStorage.removeItem(AuthKey);
  },

  checkIfLoggedId() {
    return localStorage.getItem(AuthKey) !== null;
  },

  getAuthData(): AuthData {
    return JSON.parse(atob(localStorage.getItem(AuthKey)));
  },

  isAdmin() {
    debugger
    const data = localStorage.getItem(AuthKey);
    let result = false;

    if (data) {
      const parsedData: AuthData = JSON.parse(atob(data)) as AuthData;
      result = parsedData.role === Roles.Admin;
    }

    return result;
  },

  isRegistered() {
    const data = localStorage.getItem(AuthKey);
    let result = false;

    if (data) {
      const parsedData: AuthData = JSON.parse(atob(data)) as AuthData;
      result = parsedData.role === Roles.Registered;
    }

    return result;
  }
}

export enum Roles {
  Admin = 0,
  Registered = 1
}

export const AuthKey = "auth-token"

export interface AuthData {
  name: string;
  email: string;
  role: Roles;
}
