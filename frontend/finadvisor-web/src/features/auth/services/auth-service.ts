import type { AuthResponse, LoginRequest, RegisterRequest } from "../types/auth";

const DEMO_USER = { id: "demo-user", name: "Helia", email: "demo@finadvisor.dev" };

export const authService = {
  async login(input: LoginRequest): Promise<AuthResponse> {
    // Replace this mock with:
    // return apiRequest<AuthResponse>("/identity/login", { method: "POST", body: JSON.stringify(input) });
    await new Promise((resolve) => setTimeout(resolve, 450));
    return { accessToken: "demo-token", user: { ...DEMO_USER, email: input.email } };
  },

  async register(input: RegisterRequest): Promise<AuthResponse> {
    await new Promise((resolve) => setTimeout(resolve, 450));
    return {
      accessToken: "demo-token",
      user: { id: crypto.randomUUID(), name: input.name, email: input.email },
    };
  },

  saveSession(auth: AuthResponse) {
    localStorage.setItem("finadvisor_token", auth.accessToken);
    localStorage.setItem("finadvisor_user", JSON.stringify(auth.user));
  },

  logout() {
    localStorage.removeItem("finadvisor_token");
    localStorage.removeItem("finadvisor_user");
  },

  isAuthenticated() {
    return typeof window !== "undefined" && Boolean(localStorage.getItem("finadvisor_token"));
  },
};
