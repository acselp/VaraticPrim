<template>
  <auth-layout>
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
            <FormMessage/>
          </FormItem>
        </FormField>
        <FormField label="Password" name="password" v-slot="{ componentField }">
          <FormItem>
            <FormLabel>Password</FormLabel>
            <FormControl>
              <Input type="password" placeholder="Password..." v-bind="componentField"/>
            </FormControl>
            <FormMessage/>
          </FormItem>
        </FormField>
        <form-field label="Password" name="password">
          <form-item>
            <form-control>
              <Button type="submit">
                Login
              </Button>
            </form-control>
          </form-item>
        </form-field>
      </form>
    </template>
  </auth-layout>
</template>
<script setup lang="ts">
import AuthLayout from "@/layouts/AuthLayout.vue";
import {Button, buttonVariants} from "@/components/ui/button";
import {cn} from "@/lib/utils.ts";
import {FormControl, FormItem, FormLabel, FormField, FormMessage, FormDescription} from "@/components/ui/form";
import {Input} from "@/components/ui/input";
import {useForm} from "vee-validate";
import {toTypedSchema} from "@vee-validate/zod";
import {z} from "zod";


let formSchema: any;
formSchema = toTypedSchema(z.object({
  email: z.string().min(2).max(50).email(),
  password: z.string().min(2).max(50),
}));

const form = useForm({
  validationSchema: formSchema,
})

const onSubmit = form.handleSubmit((values) => {
  console.log('Form submitted!', values)
})

</script>