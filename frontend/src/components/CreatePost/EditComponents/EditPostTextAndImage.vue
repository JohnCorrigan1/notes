<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
import EditTextArea from './EditUtils/EditTextArea.vue';

const src = ref("");
const alt = ref("");
const caption = ref("");
const body = ref("");
</script>

<template>
    <EditContainer label="Text and Image" type="Text and Image">
        <div class="w-full flex justify-between">
            <EditInput label="Image URL" v-model="src" />
            <EditInput label="Image Alt Text" v-model="alt" />
        </div>
        <EditInput label="Image Caption (optional)" v-model="caption" />
        <EditTextArea label="Body" v-model="body" />
    </EditContainer>
</template>