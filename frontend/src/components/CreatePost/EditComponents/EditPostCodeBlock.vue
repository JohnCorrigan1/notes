<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
import EditCode from './EditUtils/EditCode.vue';

const language = ref("");
const code = ref("");
</script>

<template>
    <EditContainer label="Code Block" type="Code Block">
        <EditInput label="Language" v-model="language" />
        <EditCode label="Code" v-model="code" />
    </EditContainer>
</template>
