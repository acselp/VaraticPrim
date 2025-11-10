<template>
  <div class="min-h-screen bg-background text-foreground transition-colors">
    <div class="container mx-auto p-8">
      <!-- Header with Dark Mode Toggle -->
      <div class="flex items-center justify-between mb-8">
        <h1 class="text-4xl font-bold">Shadcn Components Test</h1>
        <Button @click="toggleDarkMode" variant="outline" size="icon">
          <svg
            v-if="isDark"
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <circle cx="12" cy="12" r="4" />
            <path d="M12 2v2" />
            <path d="M12 20v2" />
            <path d="m4.93 4.93 1.41 1.41" />
            <path d="m17.66 17.66 1.41 1.41" />
            <path d="M2 12h2" />
            <path d="M20 12h2" />
            <path d="m6.34 17.66-1.41 1.41" />
            <path d="m19.07 4.93-1.41 1.41" />
          </svg>
          <svg
            v-else
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <path d="M12 3a6 6 0 0 0 9 9 9 9 0 1 1-9-9Z" />
          </svg>
        </Button>
      </div>

      <!-- Button Variants Section -->
      <div class="mb-12">
        <h2 class="text-2xl font-semibold mb-4">Button Variants</h2>
        <div class="flex flex-wrap gap-4">
          <Button variant="default">Default Button</Button>
          <Button variant="secondary">Secondary</Button>
          <Button variant="destructive">Destructive</Button>
          <Button variant="outline">Outline</Button>
          <Button variant="ghost">Ghost</Button>
          <Button variant="link">Link</Button>
        </div>

        <h3 class="text-xl font-semibold mt-6 mb-4">Button Sizes</h3>
        <div class="flex flex-wrap items-center gap-4">
          <Button size="sm">Small</Button>
          <Button size="default">Default</Button>
          <Button size="lg">Large</Button>
          <Button size="icon">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
            >
              <path d="M5 12h14" />
              <path d="m12 5 7 7-7 7" />
            </svg>
          </Button>
        </div>
      </div>

      <!-- Cards Section -->
      <div class="mb-12">
        <h2 class="text-2xl font-semibold mb-4">Card Components</h2>
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          <!-- Card 1 -->
          <Card>
            <CardHeader>
              <CardTitle>Simple Card</CardTitle>
              <CardDescription>
                This is a basic card with header and content
              </CardDescription>
            </CardHeader>
            <CardContent>
              <p class="text-muted-foreground">
                This card demonstrates the default styling with background,
                border, and proper spacing. It adapts to both light and dark
                themes.
              </p>
            </CardContent>
          </Card>

          <!-- Card 2 -->
          <Card>
            <CardHeader>
              <CardTitle>Card with Actions</CardTitle>
              <CardDescription> Card with footer buttons </CardDescription>
            </CardHeader>
            <CardContent>
              <p class="text-muted-foreground mb-4">
                This card includes action buttons in the footer to demonstrate
                interactive components.
              </p>
            </CardContent>
            <CardFooter class="flex justify-between">
              <Button variant="outline">Cancel</Button>
              <Button>Save</Button>
            </CardFooter>
          </Card>

          <!-- Card 3 -->
          <Card>
            <CardHeader>
              <CardTitle>Styled Card</CardTitle>
              <CardDescription> Testing color variables </CardDescription>
            </CardHeader>
            <CardContent class="space-y-3">
              <div class="flex items-center gap-2">
                <div class="h-4 w-4 rounded-full bg-primary" />
                <span class="text-sm">Primary Color</span>
              </div>
              <div class="flex items-center gap-2">
                <div class="h-4 w-4 rounded-full bg-secondary" />
                <span class="text-sm">Secondary Color</span>
              </div>
              <div class="flex items-center gap-2">
                <div class="h-4 w-4 rounded-full bg-accent" />
                <span class="text-sm">Accent Color</span>
              </div>
              <div class="flex items-center gap-2">
                <div class="h-4 w-4 rounded-full bg-destructive" />
                <span class="text-sm">Destructive Color</span>
              </div>
            </CardContent>
          </Card>
        </div>
      </div>

      <!-- Color Palette Test -->
      <div class="mb-12">
        <h2 class="text-2xl font-semibold mb-4">Color Palette (OKLch)</h2>
        <div class="grid grid-cols-2 md:grid-cols-4 gap-4">
          <div class="p-4 rounded-lg border bg-card">
            <div class="text-sm font-medium mb-2">Background</div>
            <div class="h-12 rounded bg-background border" />
          </div>
          <div class="p-4 rounded-lg border bg-card">
            <div class="text-sm font-medium mb-2">Muted</div>
            <div class="h-12 rounded bg-muted" />
          </div>
          <div class="p-4 rounded-lg border bg-card">
            <div class="text-sm font-medium mb-2">Primary</div>
            <div class="h-12 rounded bg-primary" />
          </div>
          <div class="p-4 rounded-lg border bg-card">
            <div class="text-sm font-medium mb-2">Secondary</div>
            <div class="h-12 rounded bg-secondary" />
          </div>
        </div>
      </div>

      <!-- Input Test -->
      <div class="mb-12">
        <h2 class="text-2xl font-semibold mb-4">Input Components</h2>
        <Card class="max-w-md">
          <CardHeader>
            <CardTitle>Form Example</CardTitle>
            <CardDescription>Testing input styling</CardDescription>
          </CardHeader>
          <CardContent class="space-y-4">
            <div class="space-y-2">
              <label class="text-sm font-medium">Email</label>
              <Input type="email" placeholder="Enter your email" />
            </div>
            <div class="space-y-2">
              <label class="text-sm font-medium">Password</label>
              <Input type="password" placeholder="Enter your password" />
            </div>
            <Button class="w-full">Submit</Button>
          </CardContent>
        </Card>
      </div>

      <!-- Status Message -->
      <div class="mt-8 p-4 rounded-lg border bg-muted/50">
        <p class="text-sm text-muted-foreground">
          <strong>Theme Status:</strong>
          {{ isDark ? "Dark Mode" : "Light Mode" }} |
          <strong>Tailwind:</strong> ✅ Working | <strong>Shadcn:</strong> ✅
          Styled
        </p>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted } from "vue";

definePageMeta({
  layout: "client",
});

const isDark = ref(false);

const toggleDarkMode = () => {
  isDark.value = !isDark.value;
  if (isDark.value) {
    document.documentElement.classList.add("dark");
  } else {
    document.documentElement.classList.remove("dark");
  }
};

onMounted(() => {
  // Check if dark mode is already set
  isDark.value = document.documentElement.classList.contains("dark");
});
</script>
