export interface Account {
  id: number;
  email: string;
  password: string;
  role: string;
  isEditingRole: boolean;
}

export enum Role {
  User,
  Admin
}


