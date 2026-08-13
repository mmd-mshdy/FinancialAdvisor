"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import { authService } from "@/features/auth/services/auth-service";

const schema = z.object({ name: z.string().min(2), email: z.string().email(), password: z.string().min(6) });
type FormValues = z.infer<typeof schema>;

export function RegisterForm() {
  const router = useRouter();
  const [error, setError] = useState("");
  const { register, handleSubmit, formState: { errors, isSubmitting } } = useForm<FormValues>({ resolver: zodResolver(schema) });

  const onSubmit = async (values: FormValues) => {
    try {
      setError("");
      const auth = await authService.register(values);
      authService.saveSession(auth);
      router.push("/dashboard");
    } catch (e) {
      setError(e instanceof Error ? e.message : "Registration failed.");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
      <div><label className="mb-2 block text-sm font-medium">Name</label><Input {...register("name")} />{errors.name && <p className="mt-1 text-sm text-red-600">{errors.name.message}</p>}</div>
      <div><label className="mb-2 block text-sm font-medium">Email</label><Input type="email" {...register("email")} />{errors.email && <p className="mt-1 text-sm text-red-600">{errors.email.message}</p>}</div>
      <div><label className="mb-2 block text-sm font-medium">Password</label><Input type="password" {...register("password")} />{errors.password && <p className="mt-1 text-sm text-red-600">{errors.password.message}</p>}</div>
      {error && <p className="text-sm text-red-600">{error}</p>}
      <Button className="w-full" disabled={isSubmitting}>{isSubmitting ? "Creating account…" : "Create account"}</Button>
    </form>
  );
}
