<script setup>
import { useClerk, useAuth, UserButton } from 'vue-clerk'
import { dark } from "@clerk/themes";

const { isSignedIn } = useAuth();
const clerk = useClerk();

const signIn = () => {
    clerk.openSignIn({ appearance: dark });
};

const profileProps = { appearance: dark };
</script>

<template>
    <nav class="flex w-full justify-between p-5">
        <RouterLink to="/">
            <img src="/favicon.png" alt="logo" class="w-14 h-14 rounded-lg" />
        </RouterLink>
        <div class="flex gap-5 items-center">

            <RouterLink to="/admin">
                <button
                    class="text-xl font-semibold text-white hover:bg-zinc-600 cursor-pointer duration-300 active:scale-[.98] bg-zinc-700 bg-opacity-80 px-3 py-2 rounded-lg">
                    My Posts
                </button>
            </RouterLink>
            <UserButton v-if="isSignedIn" after-sign-out-url="/" :appearance="dark" :user-profile-props="profileProps" />
            <button v-else
                class="text-xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]"
                @click="signIn">
                Sign in
            </button>
        </div>
    </nav>
</template>

<style>
.cl-avatarBox {
    width: 48px;
    height: 48px;
}
</style>
