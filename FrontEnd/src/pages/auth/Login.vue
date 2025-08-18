<template>
  <AuthLayout>
    <template #header-buttons>
      <a
          href="/login"
          :class="cn(
        buttonVariants({ variant: 'ghost' }),
        'absolute right-4 top-4 md:right-8 md:top-8',
      )"
      >
        Login
      </a>
    </template>

    <template #form>
      <form @submit="onSubmit" class="space-y-6">
        <FormField label="Email" name="email" v-slot="{ componentField }">
          <FormItem>
            <FormLabel>Username</FormLabel>
            <FormControl>
              <Input type="text" placeholder="Email..." v-bind="componentField"/>
            </FormControl>
            <FormDescription/>
            <FormMessage/>
          </FormItem>
        </FormField>
        <FormField label="Password" name="password" v-slot="{ componentField }">
          <FormItem>
            <FormLabel>Password</FormLabel>
            <FormControl>
              <Input type="password" placeholder="Password..." v-bind="componentField"/>
            </FormControl>
            <FormDescription/>
            <FormMessage/>
          </FormItem>
        </FormField>
        <FormField label="submit" name="submit">
          <FormItem>
            <FormControl>
              <Button type="submit">
                Login
              </Button>
            </FormControl>
          </FormItem>
        </FormField>
      </form>
    </template>
  </AuthLayout>
</template>

<script setup lang="ts">
import AuthLayout from "@/layouts/AuthLayout.vue";
import {Button, buttonVariants} from "@/components/ui/button";
import {FormControl, FormItem, FormLabel, FormField, FormMessage, FormDescription} from "@/components/ui/form";
import {Input} from "@/components/ui/input";
import {useForm} from "vee-validate";
import {toTypedSchema} from "@vee-validate/zod";
import {z} from "zod";
import {cn} from "@/lib/utils.ts";
import {AuthService} from "@/services/authService.ts";
import {useAuthStore} from "@/stores/authStore.ts";
import {useRouter} from "vue-router";
import {RouterPaths} from "@/router/routerPaths.ts";

const authStore = useAuthStore();
const router = useRouter();

let formSchema: any;
formSchema = toTypedSchema(z.object({
  email: z.string().min(2).max(50).email(),
  password: z.string().min(2).max(50),
}));

const form = useForm({
  validationSchema: formSchema,
})

const onSubmit = form.handleSubmit((values) => {
  AuthService.login({Email: values.email, Password: values.password})
      .then((res) => {
        authStore.login(res.data);
        router.push(RouterPaths.Dashboard);
      })
})

</script>