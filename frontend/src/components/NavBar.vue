<script setup lang="ts"></script>

<template>
    <nav class="flex w-full justify-between p-5">
        <RouterLink to="/">
            <h1 class="text-3xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                Notes
            </h1>
        </RouterLink>
        <ul class="flex items-center space-x-5">
            <li class="text-xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                Login
            </li>
            <li class="text-xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                Register
            </li>
        </ul>
    </nav>
</template>