<script setup lang="ts">
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
            <h1 class="text-3xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                Notes
            </h1>
        </RouterLink>
        <div class="flex gap-5 items-ceneter">
            <UserButton v-if="isSignedIn" after-sign-out-url="/" :appearance="dark" :user-profile-props="profileProps" />
            <button v-else
                class="text-xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]"
                @click="signIn">
                Sign in
            </button>
            <RouterLink to="/admin/howdidufinddis/createpost">
                <h2
                    class="opacity-0 text-2xl font-semibold text-white hover:underline cursor-pointer duration-300 active:scale-[.98]">
                    Create
                </h2>
            </RouterLink>
        </div>
    </nav>
</template>
