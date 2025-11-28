<script setup lang="ts">
definePageMeta({
  layout: "admin",
});
</script>

<template>
  <div class="space-y-4">
    <div>
      <h1 class="text-3xl font-bold">Dashboard</h1>
      <p class="text-muted-foreground">Welcome to the admin dashboard</p>
    </div>

    <div class="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
      <div class="rounded-lg border bg-card p-6">
        <h3 class="text-lg font-semibold">Total Users</h3>
        <p class="text-3xl font-bold">1,234</p>
      </div>

      <div class="rounded-lg border bg-card p-6">
        <h3 class="text-lg font-semibold">Active Sessions</h3>
        <p class="text-3xl font-bold">456</p>
      </div>

      <div class="rounded-lg border bg-card p-6">
        <h3 class="text-lg font-semibold">Revenue</h3>
        <p class="text-3xl font-bold">$12,345</p>
      </div>
    </div>
  </div>
</template>
