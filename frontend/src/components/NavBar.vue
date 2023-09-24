<script setup lang="ts"></script>

<template>
    <nav class="flex w-full justify-between p-5">
        <RouterLink to="/">
            <h1 class="text-3xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                Notes
            </h1>
        </RouterLink>
        <RouterLink to="/admin/howdidufinddis/createpost">
            <h2
                class="opacity-0 text-2xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                Create
            </h2>
        </RouterLink>
    </nav>
</template>